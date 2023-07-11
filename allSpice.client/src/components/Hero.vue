<template>
    <main class="container-fluid">
        <section class="row hero-img">
            <div class="col-12">
                <Navbar />
            </div>
            <div class="col-12 d-flex justify-content-center align-items-center text-light">
                <div class="fw-medium hero-card">
                    <h1 class="title-text">All-Spice</h1>
                    <div class="text-center">
                        <p class="mb-2">Cherish Your Family</p>
                        <p>And Their Cooking</p>
                    </div>
                </div>
            </div>
            <div class="col-10 offset-1 text-light category-container">
                <div class="d-flex justify-content-evenly align-items-center elevation-3 p-2 category-card fs-2">
                    <div>
                        <p @click="getAllRecipes()" class="home">Home</p>
                        <div v-if="checkActive('home')" class="selected"></div>
                    </div>
                    <div>
                        <p @click="getMyRecipes()" class="myRecipes">My Recipes</p>
                        <div v-if="checkActive('myRecipes')" class="selected"></div>
                    </div>
                    <div>
                        <p @click="displayMyFavorites()" class="favorites">Favorites</p>
                        <div v-if="checkActive('favorites')" class="selected"></div>
                    </div>
                </div>
            </div>
        </section>
    </main>
</template>


<script>
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';

export default {
    setup() {
        return {
            async getAllRecipes() {
                try {
                    AppState.category = 'home'
                    await recipesService.getAllRecipes()
                } catch (error) {
                    Pop.error(error, 'trouble getting all recipes')
                }
            },

            async getMyRecipes() {
                try {
                    AppState.category = 'myRecipes'
                    await recipesService.getMyRecipes()
                } catch (error) {
                    Pop.error(error, 'trouble getting your recipes')
                }
            },

            async displayMyFavorites() {
                try {
                    AppState.category = 'favorites'
                    await recipesService.displayMyFavorites()
                } catch (error) {
                    Pop.error('error getting favorites', error)
                }
            },

            checkActive(active) {
                if(AppState.category == active) {
                    return true
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>

.selected {
    background-color: yellow;
    height: .5rem;
    transition-duration: 5000ms;
}

.hero-card {
    border-radius: .5rem;
    padding: 1rem;
    backdrop-filter: blur(6px);
    background-color: rgba($color: #000000, $alpha: .2);
}
.title-text {
    font-size: 7rem;
    font-family: 'Noto Serif Makasar', serif;
}

main {
    padding-left: 0;
    padding-right: 0;
}

.category-container {
    position: relative;
    top: 2rem;
}

.category-card {
    font-family: 'Noto Serif Makasar', serif;
    height: 5rem;
    background-color: #73877B
}

.home,
.myRecipes,
.favorites {
    cursor: pointer;
}

.home:hover,
.myRecipes:hover,
.favorites:hover {
    color: yellow;
}

.hero-img {
    background-image: url("https://static.vecteezy.com/system/resources/previews/003/823/542/original/spices-for-use-as-cooking-ingredients-on-a-wooden-background-with-fresh-vegetables-healthy-food-herbs-organic-vegetables-on-the-table-raw-materials-of-cooking-preparation-tom-yum-free-photo.jpg");
    // background-position: center;
    background-size: 100%;
    background-repeat: no-repeat;
    height: 20rem;
}

p {
    margin: 0;
}
</style>