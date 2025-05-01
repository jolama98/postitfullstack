import { AppState } from "@/AppState.js";
import { Album } from "@/models/Album.js";
import { Pop } from "@/utils/Pop.js";
import { SocketHandler } from "@/utils/SocketHandler.js";

class AlbumsHandler extends SocketHandler {
  constructor() {
    super()
    this.on('CREATED_ALBUM', this.onCreatedAlbum)
  }

  onCreatedAlbum(payload) {
    Pop.toast("Someone created a new album!")
    const album = new Album(payload)
    AppState.albums.unshift(album)
  }
}

export const albumsHandler = new AlbumsHandler()
