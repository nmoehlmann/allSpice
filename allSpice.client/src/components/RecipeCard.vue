<template>

    <main class="elevation-5 food-card my-4 mx-3 d-flex flex-column justify-content-between rounded-2">
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

export default {
    props: {
        recipe: {type: Recipe, required: true}
    },
    setup(props){
        return {
            coverImg: computed(() => `url(${props.recipe.img})`)
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