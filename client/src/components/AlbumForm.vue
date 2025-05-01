<script setup>
import { albumsService } from '@/services/AlbumsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const categories = ['aesthetics', 'food', 'games', 'animals', 'misc', 'vibes']
// NOTE useRouter allows us to change route information
const router = useRouter()

const editableAlbumData = ref({
  title: '',
  coverImg: '',
  description: '',
  category: ''
})

async function createAlbum() {
  try {
    // NOTE must return the album from the service in order for this to work
    const album = await albumsService.createAlbum(editableAlbumData.value)
    editableAlbumData.value = {
      title: '',
      coverImg: '',
      description: '',
      category: ''
    }
    // NOTE hides our modal that has the id of 'albumModal'
    Modal.getOrCreateInstance('#albumModal').hide()
    // NOTE navigates the user to the Album Details page. The object that we pass to the push method is formatted the same as the 'to' prop for a RouterLink
    // router.push({ name: 'Album Details', params: { albumId: album.id } })
  } catch (error) {
    Pop.error(error, 'Could not create album')
    logger.error('COULD NOT CREATE ALBUM', error)
  }
}

</script>


<template>
  <form @submit.prevent="createAlbum()">
    <div class="form-floating mb-3">
      <input v-model="editableAlbumData.title" type="text" class="form-control" id="albumTitle"
        placeholder="Album Title..." minlength="3" maxlength="25" required>
      <label for="albumTitle">Album Title</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="editableAlbumData.coverImg" type="url" class="form-control" id="albumCoverImg"
        placeholder="Album Cover Image" maxlength="1000" required>
      <label for="albumCoverImg">Album Cover Image</label>
    </div>
    <div v-if="editableAlbumData.coverImg" class="mb-3">
      <p>Image preview</p>
      <img :src="editableAlbumData.coverImg" alt="Preview of your cover image" class="w-100">
    </div>
    <div class="form-floating mb-3">
      <textarea v-model="editableAlbumData.description" class="form-control" placeholder="Album Description"
        id="albumDescription" minlength="15" maxlength="250"></textarea>
      <label for="albumDescription">Album Description</label>
    </div>
    <div class="form-floating mb-3">
      <select v-model="editableAlbumData.category" class="form-select" id="albumCategory" aria-label="Album Category"
        required>
        <option value="" selected disabled>Choose a category</option>
        <option v-for="category in categories" :key="'option ' + category" :value="category">
          {{ category }}
        </option>
      </select>
      <label for="albumCategory">Album Category</label>
    </div>
    <div class="text-end">
      <button class="btn btn-success" type="submit">
        Submit
      </button>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>
