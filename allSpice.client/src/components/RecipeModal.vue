<template>
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content container-fluid">

      <section class="row modal-header text-light">
        <h1 class="modal-title fs-1" id="exampleModalLabel">New Recipe</h1>
      </section>

    <form @submit.prevent="createRecipe()">
        <section class="row">
            <div class="col-12 d-flex flex-column my-3">
                <label class="mb-2" for="">Title</label>
                <input type="text" placeholder="Recipe Title" v-model="editable.title" data-autofocus>
            </div>
            <div class="col-6 d-flex flex-column mb-2">
                <label class="mb-2" for="">Category</label>
                <input type="text" placeholder="Recipe Category" v-model="editable.category">
            </div>
            <div class="col-6 d-flex flex-column mb-2">
                <label class="mb-2" for="">Recipe Img Url</label>
                <input type="text" placeholder="Recipe Cover Image" v-model="editable.img">
            </div>
            <div class="col-12 d-flex flex-column">
                <label class="mb-2" for="">Recipe Instructions</label>
                <textarea name="" id="" cols="30" rows="10" placeholder="Instructions..." v-model="editable.instructions"></textarea>
            </div>
        </section>
        <!-- <form @submit.prevent="createIngredient(recipe.id)">
            <section class="row">
                <div class="col-6 d-flex flex-column text-center">
                    <label class="mb-2" for="">Add Ingredients</label>
                    <input type="text" placeholder="carrots...">
                </div>
                <div class="col-6 text-center">
                    <p>Ingredients List</p>
                </div>
            </section>
        </form> -->
        
        <section class="row my-4">
            <div class="d-flex align-items-center gap-3 justify-content-end">
                <button type="button" data-bs-dismiss="modal" class="cancel-button" aria-label="Close">Cancel</button>
                <button type="submit" class="submit-button btn btn-success" data-bs-dismiss="modal" data-bs-target="#recipeModal">Submit</button>
            </div>
        </section>
    </form>
        
      </div>
    </div>
</template>


<script>
// import { Modal } from 'bootstrap';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';
import { ref } from 'vue';

export default {
    setup(){
        const editable = ref({})
        return {
            editable,

            async createRecipe() {
                try {
                    const formData = editable.value
                    const activeModel = document.getElementById('recipeModal')
                    await recipesService.createRecipe(formData)
                    editable.value = {}
                    activeModel.addEventListener('hidden.bs.modal', event => {
                    })
                } catch (error) {
                    Pop.error('error creating recipe', error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
    .cancel-button {
        border: none;
        background-color: #e5e5e5;
    }

    .submit-button {
        margin: 0;
        padding: 5px;
    }

    p {
        margin: 0;
    }

    .modal-header {
        background-color: #4f7d6f;
    }
</style>