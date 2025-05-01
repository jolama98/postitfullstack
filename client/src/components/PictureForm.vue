<script setup>
import { picturesService } from '../services/PicturesService.js';
import { uploadsService } from '../services/UploadsService.js'
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const imgToUpload = ref(null)

const editablePictureData = ref({
  imgUrl: '',
  albumId: route.params.albumId
})

async function createPicture() {
  try {
    const imgUrl = await uploadsService.uploadImg(imgToUpload.value)
    editablePictureData.value.imgUrl = imgUrl
    await picturesService.createPicture(editablePictureData.value)
    // NOTE only need to clear the imgUrl to reset the form
    editablePictureData.value.imgUrl = ''
  } catch (error) {
    Pop.error(error, 'could not create picture')
    logger.error('could not create picture', error)
  }
}

function handleFileSelect(event) {
  const file = event.target.files[0]
  logger.log('📂', file)
  const previewUrl = URL.createObjectURL(file)
  editablePictureData.value.imgUrl = previewUrl
  imgToUpload.value = file
}

</script>


<template>
  <form @submit.prevent="createPicture()">
    <div class="form-floating mb-3">
      <input @change="handleFileSelect" type="file" accept="image/*" class="form-control" id="pictureImgUrl"
        placeholder="Picture Image URL" maxlength="1000" required>
      <label for="pictureImgUrl">Picture Image URL</label>
    </div>
    <img class="img-fluid" v-if="editablePictureData.imgUrl" :src="editablePictureData.imgUrl" alt="">
    <div class="text-end">
      <button class="btn btn-success" type="submit">
        Submit
      </button>
    </div>
  </form>
</template>


<style lang="scss" scoped></style>
