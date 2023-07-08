import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {
    async createIngredient(formData, recipeId) {
        logger.log('creating ingredient')
        formData.recipeId = recipeId
        const res = await api.post('api/ingredients', formData)
        logger.log(res.data, 'this is res.data')
        AppState.ingredients.push(new Ingredient(res.data))
        logger.log(new Ingredient(res.data), 'this is appstate')
    }

    async getIngredients(recipeId) {
        logger.log('getting ingredients')
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log(res.data, 'this is res.data')
        AppState.ingredients = res.data.map(i => new Ingredient(i))
        logger.log(AppState.ingredients, 'new ingredients array in appstate')
    }

    async deleteIngredient(ingredientId) {
        logger.log('deleting ingredient')
        const res = await api.delete(`api/ingredients/${ingredientId}`)
        logger.log('deleted', res.data)
        AppState.ingredients = AppState.ingredients.filter(i => i.id != ingredientId)
    }
}

export const ingredientsService = new IngredientsService()