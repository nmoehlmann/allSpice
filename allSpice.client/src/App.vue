<template>
  <main>
    <router-view />
  </main>
  <div 
    class="modal fade" 
    id="activeRecipeModal" 
    tabindex="-1" 
    aria-labelledby="Recipe View"
    aria-hidden="true"
    role="dialog">
    <ActiveRecipeModal />
  </div>
  <div 
    class="modal instant" 
    id="recipeModal" 
    tabindex="-1" 
    aria-labelledby="createRecipeTab"
    aria-hidden="true"
    role="dialog">
    <RecipeModal />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'

export default {
    setup() {
        return {
            appState: computed(() => AppState)
        };
    }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
