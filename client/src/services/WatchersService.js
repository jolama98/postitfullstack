import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { WatcherAlbum, WatcherProfile } from "@/models/Watcher.js"

class WatchersService {
  async createWatcher(watcherData) {
    const response = await api.post('api/watchers', watcherData)
    logger.log('CREATED WATCHER', response.data)
    const watcher = new WatcherProfile(response.data)
    AppState.watcherProfiles.push(watcher)
    AppState.activeAlbum.watcherCount++
  }
  async getWatchersByAlbumId(albumId) {
    AppState.watcherProfiles = []
    const response = await api.get(`/api/albums/${albumId}/watchers`)
    logger.log('GOT WATCHERS', response.data)
    // NOTE make sure you map into the object that supports the correct version of the many-to-many
    const watcherProfiles = response.data.map(pojo => new WatcherProfile(pojo))
    AppState.watcherProfiles = watcherProfiles
  }
  async getMyWatchedAlbums() {
    AppState.watcherAlbums = []
    const response = await api.get('account/watchers')
    logger.log('GOT MY ALBUMS I AM WATCHING', response.data)
    // NOTE make sure you map into the object that supports the correct version of the many-to-many
    const watcherAlbums = response.data.map(pojo => new WatcherAlbum(pojo))
    AppState.watcherAlbums = watcherAlbums
  }
  async deleteWatcher(watcherId) {
    const response = await api.delete(`/api/watchers/${watcherId}`)
    logger.log('DELETED WATCHER', response.data)
    const watcherAlbums = AppState.watcherAlbums
    const index = watcherAlbums.findIndex(watcher => watcher.id == watcherId)
    watcherAlbums.splice(index, 1)
  }
}

export const watchersService = new WatchersService()
