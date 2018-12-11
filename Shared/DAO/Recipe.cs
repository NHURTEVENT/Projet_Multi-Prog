using System;

namespace Shared
{
    public class Recipe
    {
        private RecipeStep[] Steps;

        public Recipe(RecipeStep[] steps)
        {
            Steps = steps;
        }
    }
}