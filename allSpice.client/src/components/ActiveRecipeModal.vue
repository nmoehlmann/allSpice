<template>
    <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content container-fluid">
            <main class="row">
                <div class="col-12 col-lg-4 recipeImg"></div>
                <section class="col-12 col-lg-8">
                    <header class="row mb-4">
                        <h1>{{ recipe?.title }}</h1>
                        <p>{{ recipe?.category }}</p>
                    </header>
                    <content class="row d-flex justify-content-evenly">
                        <div class="col-5 recipe-card elevation-2">
                            <div class="text-center card-header text-light mb-2 p-3">
                                <h2>Recipe Instructions</h2>
                            </div>
                            <div class="col-12 py-3">
                                <p>{{ recipe?.instructions }}</p>
                            </div>
                        </div>
                        <div class="col-5 recipe-card elevation-2">
                            <div class="text-center card-header text-light mb-2 p-3">
                                <h2>Ingredients</h2>
                            </div>
                            <div class="col-12 py-3">
                                <section class="row mb-3" v-for="i in ingredients" :key="i.id">
                                    <Ingredient :ingredient="i" />
                                    <!-- <li v-for="i in ingredients">{{ i.quantity }} {{ i.name }}</li> -->
                                </section>
                                <section class="row" v-if="account?.id == recipe?.creatorId">
                                    <form @submit.prevent="createIngredient(recipe?.id)">
                                        <div class="text-center my-2 fs-5">
                                            <p>Add Ingredients</p>
                                        </div>
                                        <div class="d-flex">
                                            <div class="d-flex flex-column">
                                                <input class="form-control" type="text" placeholder="Name"
                                                    v-model="editable.name" required>
                                                <input class="form-control" type="text" placeholder="Quantity"
                                                    v-model="editable.quantity" required>
                                            </div>
                                            <div class="d-flex">
                                                <button class="btn plus-button mdi mdi-plus text-light"
                                                    type="submit"></button>
                                            </div>
                                        </div>
                                    </form>
                                </section>
                            </div>
                        </div>
                    </content>
                    <div class="my-2 d-flex justify-content-end delete-recipe-button" v-if="account.id == recipe?.creatorId">
                        <button 
                        @click="deleteRecipe(recipe.id)" 
                        class="btn btn-danger mdi mdi-delete">
                        </button>
                    </div>
                </section>
            </main>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import { Modal } from 'bootstrap';


export default {
    setup() {
        const editable = ref({})

        // async function getIngredients() {
        //         // debugger
        //         try {
        //             if(AppState.activeRecipe == null) {
        //                 return
        //             }
        //             recipeId = AppState.activeRecipe.id
        //             await ingredientsService.getIngredients(recipeId)
        //         } catch (error) {
        //             Pop.error(error, 'error getting ingredients')
        //         }
        //     }

        return {
            editable,
            account: computed(() => AppState.account),
            recipe: computed(() => AppState.activeRecipe),
            recipeImg: computed(() => `url(${AppState.activeRecipe?.img})`),
            ingredients: computed(() => AppState.ingredients),

            async createIngredient(recipeId) {
                try {
                    const formData = editable.value
                    await ingredientsService.createIngredient(formData, recipeId)
                    editable.value = {}
                } catch (error) {
                    Pop.error('Error creating ingredient')
                }
            },

            async deleteRecipe(recipeId) {
                try {
                    if (await Pop.confirm("Are you sure you want to delete this recipe?")) {
                        await recipesService.deleteRecipe(recipeId)
                        const activeModel = document.getElementById('activeRecipeModal')
                        Modal.getInstance(activeModel).hide()
                        Pop.delete("Deleted Recipe")
                    }
                } catch (error) {
                    Pop.error('error deleting recipe', error)
                }
            },

            checkActiveRecipe(showHide) {
                if (showHide == 'show') {
                    if (AppState.activeRecipe != null) {
                        logger.log('activeRecipe exists')
                        return true
                    }
                }
                if (showHide == 'hide') {
                    if (AppState.activeRecipe == null) {
                        logger.log('activeRecipe doesnt exist')
                        return true
                    }
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>

.plus-button {
    background-color: #4f7d6f;
    aspect-ratio: 1/1;
    margin: .5rem;
}

p,
h1,
h2 {
    margin: 0;
}

.card-header {
    background-color: #4f7d6f;
}

.card-body {
    background-color: #bababa;
}

.recipeImg {
    height: 30rem;
    background-image: v-bind(recipeImg);
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat
}
</style>