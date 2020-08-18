namespace WorkManagementSystem.Models.Common
{
    public static class ModelsConstants
    {
        // Common - properties
        public const string InvalidInput = "Please provide a valid {0}.";
        public const string InvalidTextRange = "Please provide a valid {0} - must be between {1} and {2} symbols.";
        public const string InvalidNumberRange = "Please provide a valid {0} - must be between {1} and {2}.";
        public const string PropertyIsAlreadyValue = "{0} is already {1}.";
        public const string PropertyChangedFromTo = "{0} changed from {1} to {2}.";

        // Common - objects
        public const string InvalidObject = "Invalid {0}.";
        public const string ObjectWithNameCreated = " {0} with name '{1}' created.";
        public const string ObjectWithTitleCreated = " {0} with title '{1}' created.";
        public const string ObjectWithTitleAdded = "{0} with title '{1}' added.";
        public const string ObjectWithTitleRemoved = "{0} with title '{1}' removed.";
        public const string AlreadySuchObject = "There is already such {0}.";
        public const string NoSuchObject = "There is no such {0}.";
        public const string NoObjectsAddedYet = "No {0} added yet.";

        //Comments
        public const string CommentAdded = "Comment from '{0}' added.";

        //Assigning / Unassigning
        public const string ObjectAlreadyAssigned = "{0} is already assigned to {1}.";
        public const string ObjectAssignedTo = "Assigned to {0}.";
        public const string ObjectUnassignedFrom = "Unassigned from {0}.";

        // Unit
        public const string InvalidUnitName = "A {0}'s name must not contain non-letter characters.";
    }
}
