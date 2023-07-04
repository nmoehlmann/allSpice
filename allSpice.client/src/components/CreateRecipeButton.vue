<template>
    <button class="rounded-circle d-flex align-items-center justify-content-center" data-bs-toggle="modal" data-bs-target="#recipeModal">
        <i class="mdi mdi-plus"></i>
    </button>
</template>


<script>
export default {
    setup(){
        return {}
    }
}
</script>


<style lang="scss" scoped>
    button {
        height: 4rem;
        aspect-ratio: 1/1;
        background-color: #4f7d6f;
        color: white;
        border: none;
    }

    i {
        font-size: 3rem;
    }
</style>