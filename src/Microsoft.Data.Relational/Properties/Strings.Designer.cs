// <auto-generated />
namespace Microsoft.Data.Relational
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Strings
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.Data.Relational.Strings", typeof(Strings).GetTypeInfo().Assembly);

        /// <summary>
        /// The string argument '{argumentName}' cannot be empty.
        /// </summary>
        internal static string ArgumentIsEmpty
        {
            get { return GetString("ArgumentIsEmpty"); }
        }

        /// <summary>
        /// The string argument '{argumentName}' cannot be empty.
        /// </summary>
        internal static string FormatArgumentIsEmpty(object argumentName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ArgumentIsEmpty", "argumentName"), argumentName);
        }

        /// <summary>
        /// The value provided for argument '{argumentName}' must be a valid value of enum type '{enumType}'.
        /// </summary>
        internal static string InvalidEnumValue
        {
            get { return GetString("InvalidEnumValue"); }
        }

        /// <summary>
        /// The value provided for argument '{argumentName}' must be a valid value of enum type '{enumType}'.
        /// </summary>
        internal static string FormatInvalidEnumValue(object argumentName, object enumType)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidEnumValue", "argumentName", "enumType"), argumentName, enumType);
        }

        /// <summary>
        /// The schema qualified name '{name}' is invalid. Schema qualified names must be of the form [&lt;schema_name&gt;.]&lt;object_name&gt;.
        /// </summary>
        internal static string InvalidSchemaQualifiedName
        {
            get { return GetString("InvalidSchemaQualifiedName"); }
        }

        /// <summary>
        /// The schema qualified name '{name}' is invalid. Schema qualified names must be of the form [&lt;schema_name&gt;.]&lt;object_name&gt;.
        /// </summary>
        internal static string FormatInvalidSchemaQualifiedName(object name)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("InvalidSchemaQualifiedName", "name"), name);
        }

        /// <summary>
        /// Can not create a ModificationFunction for an entity in state '{entityState}'.
        /// </summary>
        internal static string ModificationFunctionInvalidEntityState
        {
            get { return GetString("ModificationFunctionInvalidEntityState"); }
        }

        /// <summary>
        /// Can not create a ModificationFunction for an entity in state '{entityState}'.
        /// </summary>
        internal static string FormatModificationFunctionInvalidEntityState(object entityState)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ModificationFunctionInvalidEntityState", "entityState"), entityState);
        }

        /// <summary>
        /// Update failed. Expected {expectedRows} row(s) but {actualRows} row(s) returned.
        /// </summary>
        internal static string UpdateConcurrencyException
        {
            get { return GetString("UpdateConcurrencyException"); }
        }

        /// <summary>
        /// Update failed. Expected {expectedRows} row(s) but {actualRows} row(s) returned.
        /// </summary>
        internal static string FormatUpdateConcurrencyException(object expectedRows, object actualRows)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("UpdateConcurrencyException", "expectedRows", "actualRows"), expectedRows, actualRows);
        }

        /// <summary>
        /// Propagating results failed. The table '{tableName}' has no columns with store generated values but store generated values were returned by a modification command.
        /// </summary>
        internal static string NoStoreGenColumnsToPropagateResults
        {
            get { return GetString("NoStoreGenColumnsToPropagateResults"); }
        }

        /// <summary>
        /// Propagating results failed. The table '{tableName}' has no columns with store generated values but store generated values were returned by a modification command.
        /// </summary>
        internal static string FormatNoStoreGenColumnsToPropagateResults(object tableName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("NoStoreGenColumnsToPropagateResults", "tableName"), tableName);
        }

        /// <summary>
        /// Propagating results failed. The table '{tableName}' has columns with store generated values but no store generated values were returned by a modification command.
        /// </summary>
        internal static string ResultsNotPropagatedForStoreGenColumns
        {
            get { return GetString("ResultsNotPropagatedForStoreGenColumns"); }
        }

        /// <summary>
        /// Propagating results failed. The table '{tableName}' has columns with store generated values but no store generated values were returned by a modification command.
        /// </summary>
        internal static string FormatResultsNotPropagatedForStoreGenColumns(object tableName)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("ResultsNotPropagatedForStoreGenColumns", "tableName"), tableName);
        }

        /// <summary>
        /// A modification command returned more than one row. Each modification command must return at most one row.
        /// </summary>
        internal static string TooManyRowsForModificationCommand
        {
            get { return GetString("TooManyRowsForModificationCommand"); }
        }

        /// <summary>
        /// A modification command returned more than one row. Each modification command must return at most one row.
        /// </summary>
        internal static string FormatTooManyRowsForModificationCommand()
        {
            return GetString("TooManyRowsForModificationCommand");
        }

        /// <summary>
        /// Store generated values has already been saved for this command.
        /// </summary>
        internal static string StoreGenValuesSavedMultipleTimesForCommand
        {
            get { return GetString("StoreGenValuesSavedMultipleTimesForCommand"); }
        }

        /// <summary>
        /// Store generated values has already been saved for this command.
        /// </summary>
        internal static string FormatStoreGenValuesSavedMultipleTimesForCommand()
        {
            return GetString("StoreGenValuesSavedMultipleTimesForCommand");
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);
    
            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
