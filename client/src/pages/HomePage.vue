<script setup>
import { computed, onMounted } from 'vue';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { albumsService } from '../services/AlbumsService.js'

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
  <div class="container">
    <div class="row">
      <div class="col-12">

        <!-- <div v-for="album in albums" class="col-md-4"> -->

        <!-- </div> -->
      </div>
    </div>

  </div>
</template>

<style scoped lang="scss"></style>
