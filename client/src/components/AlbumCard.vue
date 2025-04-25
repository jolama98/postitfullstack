<script setup>
import { Album } from '../models/Album.js';

defineProps({
  album: {
    type: Album, required: true
  }
})
</script>


<template>
  <h1>{{ album.title }}</h1>
</template>


<style lang="scss" scoped></style>
