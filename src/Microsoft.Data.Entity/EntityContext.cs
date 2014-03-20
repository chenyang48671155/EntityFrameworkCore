// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity
{
    public class EntityContext : IDisposable
    {
        private readonly EntityConfiguration _configuration;
        private readonly LazyRef<IModel> _model;
        private readonly LazyRef<StateManager> _stateManager;
        private readonly LazyRef<ContextEntitySets> _sets;

        /// <summary>
        ///     This constructor is intended only for use when creating test doubles that will override members
        ///     with mocked or faked behavior. Use of this constructor for other purposes may result in unexpected
        ///     behavior including but not limited to throwing <see cref="NullReferenceException" />.
        /// </summary>
        protected EntityContext()
        {
        }

        public EntityContext([NotNull] EntityConfiguration configuration)
        {
            Check.NotNull(configuration, "configuration");

            _configuration = configuration;
            _model = new LazyRef<IModel>(() => _configuration.Model ?? _configuration.ModelSource.GetModel(this));
            _stateManager = new LazyRef<StateManager>(() => _configuration.StateManagerFactory.Create(_model.Value));
            _sets = new LazyRef<ContextEntitySets>(() => new ContextEntitySets(this, _configuration.EntitySetSource));

            _configuration.EntitySetInitializer.InitializeSets(this);
        }

        public virtual int SaveChanges()
        {
            // TODO: May need a parallel code path :-(
            return SaveChangesAsync().Result;
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _configuration.DataStore.SaveChangesAsync(_stateManager.Value.StateEntries, _model.Value, cancellationToken);
        }

        public void Dispose()
        {
            // TODO
        }

        public virtual TEntity Add<TEntity>([NotNull] TEntity entity)
        {
            Check.NotNull(entity, "entity");

            return AddAsync(entity, CancellationToken.None).Result;
        }

        public virtual Task<TEntity> AddAsync<TEntity>([NotNull] TEntity entity)
        {
            Check.NotNull(entity, "entity");

            return AddAsync(entity, CancellationToken.None);
        }

        public virtual async Task<TEntity> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken)
        {
            Check.NotNull(entity, "entity");

            await _stateManager.Value.GetOrCreateEntry(entity).SetEntityStateAsync(EntityState.Added, cancellationToken).ConfigureAwait(false);

            return entity;
        }

        public virtual TEntity Update<TEntity>([NotNull] TEntity entity)
        {
            Check.NotNull(entity, "entity");

            ChangeTracker.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual Task<TEntity> UpdateAsync<TEntity>([NotNull] TEntity entity)
        {
            Check.NotNull(entity, "entity");

            return UpdateAsync(entity, CancellationToken.None);
        }

        public virtual Task<TEntity> UpdateAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken)
        {
            Check.NotNull(entity, "entity");

            return Task.FromResult(Update(entity));
        }

        public virtual TEntity Delete<TEntity>([NotNull] TEntity entity)
        {
            Check.NotNull(entity, "entity");

            ChangeTracker.Entry(entity).State = EntityState.Deleted;

            return entity;
        }

        public virtual Database Database
        {
            get { return new Database(); }
        }

        public virtual ChangeTracker ChangeTracker
        {
            get { return new ChangeTracker(_stateManager.Value); }
        }

        public virtual IModel Model
        {
            get { return _model.Value; }
        }

        public virtual EntityConfiguration Configuration
        {
            get { return _configuration; }
        }

        public virtual EntitySet Set([NotNull] Type entityType)
        {
            Check.NotNull(entityType, "entityType");

            // Note: Creating sets needs to be fast because it is done eagerly when a context instance
            // is created so we avoid loading metadata to validate the type here.
            return _sets.Value.GetEntitySet(entityType);
        }

        public virtual EntitySet<TEntity> Set<TEntity>() where TEntity : class
        {
            // Note: Creating sets needs to be fast because it is done eagerly when a context instance
            // is created so we avoid loading metadata to validate the type here.
            return _sets.Value.GetEntitySet<TEntity>();
        }
    }
}
