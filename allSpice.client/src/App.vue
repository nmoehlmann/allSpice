<template>
  <main>
    <router-view />
  </main>

  <Modal class="modal instant" id="recipeModal" tabindex="-1" aria-labelledby="createRecipeTab" aria-hidden="true"
    role="dialog">
    <RecipeModal />
  </Modal>
  <Modal class="modal instant" id="activeRecipeModal" tabindex="-1" aria-labelledby="recipeTab" aria-hidden="true"
    role="dialog">
    <ActiveRecipeModal />
  </Modal>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'

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

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
