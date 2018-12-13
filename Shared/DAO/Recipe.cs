using System;

namespace Shared
{
    /// <summary>
    /// List of steps to complete to prepare a dish
    /// </summary>
    public class Recipe
    {
        public RecipeStep[] Steps { get; set; }

        public Recipe(RecipeStep[] steps)
        {
            Steps = steps;
        }
    }
}