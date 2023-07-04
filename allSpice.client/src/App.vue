<template>
  <main>
    <router-view />
  </main>

  <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="createRecipeTab" aria-hidden="true">
    <RecipeModal />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}
</style>
