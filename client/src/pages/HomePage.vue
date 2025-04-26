<script setup>
import { onMounted, computed, ref } from 'vue';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { albumsService } from '../services/AlbumsService.js'
import { AppState } from '@/AppState.js';
import AlbumCard from '../components/AlbumCard.vue';
const account = computed(() => AppState.account)
const albums = computed(() => {
  if (filterCategory.value == 'all') {
    return AppState.albums
  }

  return AppState.albums.filter(album => album.category == filterCategory.value)
})
const filterCategory = ref('all')

const categories = [
  {
    name: 'all',
    backgroundImg: 'https://images.unsplash.com/photo-1465101162946-4377e57745c3?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8c3RhcnJ5JTIwc2t5fGVufDB8MHwwfHx8Mg%3D%3D'
  },
  {
    name: 'aesthetics',
    backgroundImg: 'https://images.unsplash.com/photo-1544198365-f5d60b6d8190?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8bW91bnRhaW58ZW58MHwwfDB8fHwy'
  },
  {
    name: 'food',
    backgroundImg: 'https://images.unsplash.com/photo-1550507992-eb63ffee0847?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8c2FuZHdpY2h8ZW58MHwwfDB8fHwy'
  },
  {
    name: 'games',
    backgroundImg: 'https://images.unsplash.com/photo-1553640627-57a6de3bf0ff?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8YXJjYWRlfGVufDB8MHwwfHx8Mg%3D%3D'
  },
  {
    name: 'animals',
    backgroundImg: 'https://images.unsplash.com/photo-1532386236358-a33d8a9434e3?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGNhdHN8ZW58MHwwfDB8fHwy'
  },
  {
    name: 'misc',
    backgroundImg: 'https://images.unsplash.com/photo-1552083974-186346191183?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YWJzdHJhY3R8ZW58MHwwfDB8fHwy'
  },
  {
    name: 'vibes',
    backgroundImg: 'https://images.unsplash.com/photo-1564415051543-cb73a7468103?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dmliZXN8ZW58MHwwfDB8fHwy'
  },
]

onMounted(() => {
  getAlbums()
})

async function getAlbums() {
  try {
    await albumsService.getAlbums()
  } catch (error) {
    Pop.error(error, 'Could not get albums')
    logger.error('COULD NOT GET ALBUMS', error)
  }
}

</script>

<template>
  <div class="container fredoka-font">
    <div class="row">
      <div class="col-12">
        <div class="border-bottom border-grey my-2">
          <span class="fs-5 fw-bold">Find Your Interest</span>
        </div>
      </div>
    </div>
    <div class="row">
      <div v-for="category in categories" :key="'filter ' + category.name" class="col-6 col-md-3">
        <div @click="filterCategory = category.name"
          class="p-4 fs-3 fw-bold text-center rounded mb-2 category-button text-shadow"
          :style="{ backgroundImage: `url(${category.backgroundImg})` }" role="button"
          :title="`Filter albums by ${category.name}`">
          {{ category.name }}
        </div>
      </div>
      <div v-if="account" class="col-6 col-md-3">
        <div class="p-4 fs-3 fw-bold text-center rounded mb-2 category-button text-shadow create-button" role="button"
          title="Create new album" data-bs-toggle="modal" data-bs-target="#albumModal">
          Create +
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="border-bottom border-grey my-2">
          <span class="fs-5 fw-bold">Popular Albums</span>
        </div>
      </div>
      <div v-for="album in albums" :key="album.id" class="col-md-4">
        <AlbumCard :album="album" />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss"></style>
