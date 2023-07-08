<template>
 <header class="container-fluid">
  <Hero />
 </header>
 <main class="container">
  <section class="row">
    <div class="col-4" v-for="r in recipes" :key="r.id">
      <RecipeCard :recipe="r"/>
    </div>
  </section>
 </main>
 <footer class="footer container-fluid d-flex justify-content-end">
  <CreateRecipeButton />
 </footer>
</template>

<script>
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
import { computed, onMounted } from 'vue';
import CreateRecipeButton from '../components/CreateRecipeButton.vue';
import { logger } from '../utils/Logger';
import { accountService } from '../services/AccountService';
import { Account } from '../models/Account';


export default {
    setup() {

      function timeoutForFavorites() {
        setTimeout(getMyFavorites, 2000)
      }

      async function getMyFavorites() {
        try {
          await recipesService.getMyFavorites()
        } catch (error) {
          Pop.error('error getting favorites', error)
        }
      }

        async function getAllRecipes() {
            try {
                await recipesService.getAllRecipes();
            }
            catch (error) {
                Pop.error(error, "getting all recipes");
            }
        }
        onMounted(() => {
            getAllRecipes();
            timeoutForFavorites();
        });
        return {
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { CreateRecipeButton }
}
</script>

<style scoped lang="scss">

  .footer {
    height: 5rem;
    bottom: 0;
    position: fixed;
  }

</style>
