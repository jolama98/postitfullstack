import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"



class UploadsService {
  async uploadImg(imgFile) {
    logger.log('📩', imgFile)
    const uploadForm = new FormData()
    uploadForm.append('upload', imgFile)
    const response = await api.post('api/upload', uploadForm)
    logger.log('🪿', response.data)
    return response.data.url
  }
}

export const uploadsService = new UploadsService()
