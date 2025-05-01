<script setup>
import { AppState } from '../AppState.js';
import { Picture } from '@/models/Picture.js';
import { picturesService } from '@/services/PicturesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const props = defineProps({
  picture: { type: Picture, required: true }
})

const account = computed(() => AppState.account)
const identity = computed(() => AppState.identity)

async function deletePicture(pictureId) {
  const confirmed = await Pop.confirm('Are you sure you want to delete this picture?')
  if (!confirmed) return

  try {
    await picturesService.deletePicture(pictureId)
  } catch (error) {
    logger.error('COULD NOT DELETE PICTURE', error)
    Pop.error(error, 'Could not delete picture')
  }
}
async function destroyPicture(pictureId) {
  const confirmed = await Pop.confirm(`Are you sure you want to permanently delete ${props.picture.creator.name}'s picture?`)
  if (!confirmed) return

  try {
    await picturesService.destroyPicture(pictureId)
  } catch (error) {
    logger.error('COULD NOT DELETE PICTURE', error)
    Pop.error(error, 'Could not delete picture')
  }
}
</script>


<template>
  <div class="position-relative">
    <img :src="picture.imgUrl" :alt="'a picture submitted by ' + picture.creator.name" class="w-100">
    <button v-if="account?.id == picture.creatorId" @click="deletePicture(picture.id)" type="button"
      class="btn btn-danger rounded-circle position-absolute" title="Delete your picture">
      <span class="mdi mdi-delete"></span>
    </button>
    <button v-else-if="identity.permissions.includes('delete:pictures')" @click="destroyPicture(picture.id)"
      class="btn btn-red rounded-circle position-absolute" type="button"
      :title="`Delete ${picture.creator.name}'s picture`">
      <span class="mdi mdi-delete-forever"></span>
    </button>
    <div class="position-absolute">
      <img :src="picture.creator.picture" :alt="'A piture of ' + picture.creator.name" class="round-picture me-2"
        height="30">
      <kbd>{{ picture.creator.name }}</kbd>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.position-absolute {
  opacity: 0;
  transition: 500ms ease-in-out;
}

button {
  top: 0;
  right: 0;
}

div.position-absolute {
  bottom: 0;
}

.position-relative:hover .position-absolute {
  opacity: 1;
}
</style>
