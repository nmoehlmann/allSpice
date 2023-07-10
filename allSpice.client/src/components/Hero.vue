<template>
    <main class="container-fluid">
        <section class="row hero-img">
            <div class="col-12">
                <Navbar />
            </div>
            <div class="col-12 d-flex justify-content-center align-items-center text-light">
                <div class="fw-medium">
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
                        <div></div>
                    </div>
                    <p @click="getMyRecipes()" class="myRecipes">My Recipes</p>
                    <p @click="displayMyFavorites()" class="favorites">Favorites</p>
                </div>
            </div>
        </section>
    </main>
</template>


<script>
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';

export default {
    setup() {
        return {
            async getAllRecipes() {
                try {
                    await recipesService.getAllRecipes()
                } catch (error) {
                    Pop.error(error, 'trouble getting all recipes')
                }
            },

            async getMyRecipes() {
                try {
                    await recipesService.getMyRecipes()
                } catch (error) {
                    Pop.error(error, 'trouble getting your recipes')
                }
            },

            async displayMyFavorites() {
                try {
                    await recipesService.displayMyFavorites()
                } catch (error) {
                    Pop.error('error getting favorites', error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
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
    top: 4rem;
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