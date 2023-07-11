<template>
    <section class="row">
        <div class="col-10">
            <li>{{ ingredient.quantity }} {{ ingredient.name }}</li>
        </div>
        <div class="col-2 d-flex align-items-center">
            <button @click="deleteIngredient(ingredient.id)" class="deleteIngredientButton d-flex align-items-center"><i
                    class="mdi mdi-minus-thick"></i></button>
        </div>
    </section>
</template>


<script>
import { Ingredient } from '../models/Ingredient';
import { ingredientsService } from '../services/IngredientsService';
import Pop from '../utils/Pop';

export default {
    props: {
        ingredient: { Type: Ingredient, required: true }
    },
    setup() {
        return {
            async deleteIngredient(ingredientId) {
                try {
                    await ingredientsService.deleteIngredient(ingredientId)
                } catch (error) {
                    Pop.error('error deleting ingredient', error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.deleteIngredientButton {
    background: rgba($color: #000000, $alpha: 0);
    border: none;
    height: 1rem;
    aspect-ratio: 1/1;
    color: red;
}
</style>