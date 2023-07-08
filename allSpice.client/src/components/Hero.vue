<template>
    <main class="container-fluid">
        <section class="row hero-img">
            <div class="col-12">
                <Navbar />
            </div>
            <div class="col-12 d-flex justify-content-center align-items-center">
                <div class="fw-medium">
                    <h1 class="display-1">All-Spice</h1>
                    <div class="text-center">
                        <p class="mb-2">Cherish Your Family</p>
                        <p>And Their Cooking</p>
                    </div>
                </div>
            </div>
            <div class="col-6 offset-3">
                <div class="d-flex justify-content-evenly elevation-3 p-2">
                    <p @click="getAllRecipes()" class="home">Home</p>
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
    setup(){
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

    .home, .myRecipes, .favorites {
        cursor: pointer;
    }
    .hero-img {
        background-image: url("https://i0.wp.com/diplomartbrussels.com/wp-content/uploads/2020/09/food-background-images-94-images-in-co-381169-png-images-pngio-food-background-png-1440_619.png?fit=1440%2C619&ssl=1");
        // background-position: center;
        background-size: 100%;
        background-repeat: no-repeat;
        height: 20rem;
    }

    p {
        margin: 0;
    }
</style>