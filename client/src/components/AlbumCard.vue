<script setup>
import { Album } from '@/models/Album.js';

defineProps({
  album: { type: Album, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'Album Details', params: { albumId: album.id } }" :title="`Go to the ${album.title} page!`">
    <div class="rounded shadow p-2 album-card mb-3 d-flex align-items-end text-light"
      :style="{ backgroundImage: `url(${album.coverImg})` }">
      <div class="d-flex justify-content-between align-items-center bg-dark-glass rounded p-2 flex-grow-1">
        <div>
          <p class="fw-bold mb-1">{{ album.title }}</p>
          <div>
            <img :src="album.creator.picture" :alt="'A picture of ' + album.creator.name" class="round-picture me-2">
            <span>{{ album.creator.name }}</span>
          </div>
        </div>
        <div
          :title="album.watcherCount + (album.watcherCount == 1 ? ' person is ' : ' people are ') + 'watching this album'">
          <span class="mdi mdi-account-multiple me-2"></span>
          <span>{{ album.watcherCount }}</span>
        </div>
      </div>
    </div>
  </RouterLink>
</template>


<style lang="scss" scoped>
.album-card {
  min-height: 30dvh;
  background-size: cover;
  background-position: center;
}

img {
  height: 2rem;
}

a {
  text-decoration: none;
}

a:hover {
  color: var(--bs-light);
  text-decoration: underline;
}
</style>
