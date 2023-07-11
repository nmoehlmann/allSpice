<template>
    <main class="elevation-3 my-3 mx-3 d-flex flex-column justify-content-between food-card-background">
        <section class="my-3 mx-3 d-flex flex-column justify-content-between rounded-2 food-card" data-bs-toggle="modal"
            data-bs-target="#activeRecipeModal" @click="getActiveRecipe(recipe.id)">
            <section class="d-flex justify-content-between text-light">
                <div class="text p-1 m-2">{{ recipe.category }}</div>
            </section>
            <section class="text-light">
                <div class="text p-1 m-2 d-flex align-items-center">
                    <p>{{ recipe.title }}</p>
                </div>
            </section>
        </section>
        <section class="row">
            <div class="d-flex justify-content-between align-items-center px-5">
                <p class="fw-bold fs-5">{{ recipe.creator.name }}</p>
                <div v-if="checkFavorite(recipe.id, 'favorite')" @click="favoriteRecipe(recipe.id)"
                    class="favorite-button p-1 m-2 rounded-5 d-flex justify-content-center align-items-center fs-3 text-light">
                    <i class="mdi mdi-heart"></i>
                </div>
                <div v-if="checkFavorite(recipe.id, 'unfavorite')" @click="unfavoriteRecipe(recipe.id)"
                    class="unfavorite-button p-1 m-2 rounded-5 d-flex justify-content-center align-items-center fs-3"><i
                        class="mdi mdi-heart"></i></div>
            </div>
        </section>
    </main>
</template>


<script>
import { computed } from 'vue';
import { Recipe } from '../models/Recipe';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService';
// import { logger } from '../utils/Logger';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup(props) {
        return {
            coverImg: computed(() => `url(${props.recipe.img})`),

            checkFavorite(recipeId, favUnfav) {
                if (favUnfav == 'favorite') {
                    let favorite = AppState.favorites.find(f => f.id == recipeId)
                    if (favorite) {
                        return false
                    } else {
                        return true
                    }
                }
                if (favUnfav == 'unfavorite') {
                    let favorite = AppState.favorites.find(f => f.id == recipeId)
                    if (favorite) {
                        return true
                    } else {
                        return false
                    }
                }
            },

            async getActiveRecipe(recipeId) {
                // debugger
                try {
                    AppState.activeRecipe = {}
                    await recipesService.getActiveRecipe(recipeId)
                    await ingredientsService.getIngredients(recipeId)
                } catch (error) {
                    Pop.error('Couldnt get that recipe and/or ingredients', error)
                }
            },

            async favoriteRecipe(recipeId) {
                try {
                    await recipesService.favoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error, 'error favoriting recipe')
                }
            },

            async unfavoriteRecipe(recipeId) {
                try {
                    await recipesService.unfavoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error, 'error unfavoriting recipe')
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.food-card-background {
    background-color: #F5E4D7;
}

.unfavorite-button {
    cursor: pointer;
    height: 2.5rem;
    aspect-ratio: 1/1;
    background-color: black;
    color: red
}

.favorite-button {
    cursor: pointer;
    height: 2.5rem;
    aspect-ratio: 1/1;
    background-color: black;
    z-index: 2;
}

p {
    margin: 0;
}

.food-card {
    aspect-ratio: 1/1;
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: fill;
    background-repeat: no-repeat;
    cursor: pointer;
}

.text {
    background: rgba($color: #6e6e6e, $alpha: .7);
    border-radius: 4px;
    font-weight: 800;
}
</style>