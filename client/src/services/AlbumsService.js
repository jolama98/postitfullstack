import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class AlbumsService {

  async getAlbums() {
    const response = await api.get('api/albums')
    logger.log('Got albums', response.data)
  }
}
export const albumsService = new AlbumsService()
