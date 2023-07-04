import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async getAllRecipes() {
        const res = await api.get('api/recipes')
        logger.log(res.data)
        AppState.recipes = res.data.map(r => new Recipe(r))
        logger.log(AppState.recipes, 'this is my appstate')
    }

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        logger.log(res.data)
        
        AppState.recipes.unshift(new Recipe(res.data))
    }

    async getActiveRecipe(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log(res.data, 'this is the active recipe')
        AppState.activeRecipe = new Recipe(res.data)
    }
}

export const recipesService = new RecipesService()