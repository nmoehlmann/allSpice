import { Modal } from "bootstrap"
import { AppState } from "../AppState"
import { Recipe, SubscriptionRecipe } from "../models/Recipe"
import { Subscriber } from "../models/Subscriber"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async getAllRecipes() {
        const res = await api.get('api/recipes')
        logger.log(res.data)
        AppState.recipes = res.data.map(r => new Recipe(r))
        logger.log(AppState.recipes, 'this is my appstate')
        AppState.savedRecipes = AppState.recipes
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

    async getMyRecipes() {
        const res = await api.get('api/recipes')
        const myRecipes = res.data.filter(r => r.creatorId == AppState.account.id)
        logger.log(myRecipes)
        AppState.recipes = myRecipes.map(r => new Recipe(r))
        logger.log(AppState.recipes, 'new array for my recipes')
        AppState.savedRecipes = AppState.recipes
    }

    async favoriteRecipe(recipeId) {
        const res = await api.post('api/favorites', new Subscriber({recipeId}))
        logger.log(res.data)
        this.getMyFavorites()
    }

    async unfavoriteRecipe(recipeId) {
        let sub = AppState.favorites.find(f => f.id == recipeId)
        if(!sub) {
            logger.log("you arent subbed to this recipe")
            return
        }
        const res = await api.delete(`api/favorites/${sub.subscriptionId}`)
        logger.log(res.data)
        AppState.favorites = AppState.favorites.filter(f => f.id != recipeId)
        logger.log(AppState.subscribers)
    }

    async getMyFavorites() {
        const res = await api.get('/account/favorites')
        logger.log(res.data, 'favorites')
        AppState.favorites = res.data.map(r => new SubscriptionRecipe(r))
        logger.log(AppState.favorites)
    }

    async displayMyFavorites() {
        const res = await api.get('/account/favorites')
        logger.log(res.data, 'displaying favorites')
        AppState.recipes = res.data.map(r => new SubscriptionRecipe(r))
        AppState.savedRecipes = AppState.recipes
    }

    async deleteRecipe(recipeId) {
        const res = await api.delete(`api/recipes/${recipeId}`)
        logger.log('deleted', res.data)
        AppState.recipes = AppState.recipes.filter(r => r.id != recipeId)
    }
}

export const recipesService = new RecipesService()