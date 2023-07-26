<template>
  <section class="row navbar">
    <h1>HI</h1>
    <div class="d-flex justify-content-end align-items-center gap-3">
      <div class="search-bar">
        <input @input.prevent="searchRecipes()" type="text" placeholder="Search Recipes" v-model="search"
          class="">
      </div>
      <Login />
    </div>
  </section>
</template>

<script>
import { ref } from "vue";
// import Pop from "../utils/Pop.js";
import Login from './Login.vue';
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
export default {
  setup() {
    const search = ref('')
    return {
      search,

      async searchRecipes() {
        try {
          let newRecipeList = []
          AppState.recipes = AppState.savedRecipes
          AppState.recipes.forEach(r => {
            if (r.title.toLowerCase().includes(search.value.toLowerCase())) {
              newRecipeList.push(r)
              AppState.recipes = newRecipeList
            }
          })
          // await recipesService.searchRecipe()
        } catch (error) {
          logger.log(error)
          // Pop.error('error searching', error)
        }
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>

.search-bar {
  
}
.navbar {
  height: 1rem;
}
</style>
