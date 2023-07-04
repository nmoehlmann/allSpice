<template>
  <section class="row navbar">
    <div class="d-flex justify-content-end">
      <Login />
    </div>
  </section>
</template>

<script>
import Login from './Login.vue';
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
.navbar {
  height: 1rem;
}
</style>
