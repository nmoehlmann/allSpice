<template>

    <main class="elevation-5 food-card my-4 mx-3 d-flex flex-column justify-content-between rounded-2" data-bs-toggle="modal" data-bs-target="#activeRecipeModal" @click="getActiveRecipe(recipe.id)">
        <section class="d-flex justify-content-between text-light">
            <div class="text p-1 m-2">{{ recipe.category }}</div>
            <div class="text p-1 m-2"><i class="mdi mdi-heart"></i></div>
        </section>
        <section class="text-light">
            <div class="text p-1 m-2 d-flex align-items-center">
                <p>{{ recipe.title }}</p>
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

export default {
    props: {
        recipe: {type: Recipe, required: true}
    },
    setup(props){
        return {
            coverImg: computed(() => `url(${props.recipe.img})`),

            async getActiveRecipe(recipeId) {
                // debugger
                try {
                    await recipesService.getActiveRecipe(recipeId)
                    await ingredientsService.getIngredients(recipeId)
                } catch (error) {  
                    Pop.error('Couldnt get that recipe and/or ingredients', error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>

    p {
        margin: 0;
    }
    .food-card {
        aspect-ratio: 1/1;
        background-image: v-bind(coverImg);
        background-position: center;
        background-size: fill;
        background-repeat: no-repeat;
    }

    .text {
        background: rgba($color: #6e6e6e, $alpha: .7);
        border-radius: 4px;
        font-weight: 800;
    }
</style>