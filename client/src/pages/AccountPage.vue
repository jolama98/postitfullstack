<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Pop } from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { watchersService } from '@/services/WatchersService.js';
import AlbumCard from '@/components/AlbumCard.vue';

const account = computed(() => AppState.account)
const watcherAlbums = computed(() => AppState.watcherAlbums)

onMounted(() => {
  getMyWatchedAlbums()
})

async function getMyWatchedAlbums() {
  try {
    await watchersService.getMyWatchedAlbums()
  } catch (error) {
    Pop.error(error, 'could not get albums')
    logger.error('could not get albums'.toUpperCase(), error)
  }
}

async function deleteWatcher(watcherId) {
  try {
    const confirmed = await Pop.confirm("Are you sure you do not want to watch this album any longer?")
    if (!confirmed) {
      return
    }
    await watchersService.deleteWatcher(watcherId)
  } catch (error) {
    Pop.error(error, 'could not delete')
    logger.error('could not delete'.toUpperCase(), error)
  }
}

</script>

<template>
  <div>
    <div v-if="account">
      <div class="container">
        <div class="row">
          <div class="col-12">
            <div class="text-center my-3">
              <span>Welcome back {{ account.name }}</span>
              <img :src="account.picture" :alt="account.name" class="account-img ms-3 round-picture">
              <p class="mt-3">You are watching {{ watcherAlbums.length }} albums</p>
            </div>
          </div>
        </div>
        <div class="row">
          <div v-for="watcher in watcherAlbums" :key="watcher.id" class="col-md-4">
            <AlbumCard :album="watcher.album" />
            <div class="text-end mb-5">
              <button @click="deleteWatcher(watcher.id)" class="btn btn-danger">
                Leave <span class="mdi mdi-door-open"></span>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
.account-img {
  height: 7rem;
}
</style>
