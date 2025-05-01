import { AppState } from "@/AppState.js";
import { Picture } from "@/models/Picture.js";
import { Pop } from "@/utils/Pop.js";
import { SocketHandler } from "@/utils/SocketHandler.js";

export class PicturesHandler extends SocketHandler {
  constructor() {
    super()
    this.on('CREATED_PICTURE', this.onCreatedPicture)
    this.on('CREATED_PICTURE_FOR_USER_ALBUM', this.onCreatedPictureForUserAlbum)
  }

  onCreatedPicture(payload) {
    const picture = new Picture(payload)
    AppState.pictures.push(picture)
  }

  onCreatedPictureForUserAlbum(payload) {
    const picture = new Picture(payload)
    Pop.toast(`${picture.creator.name} just added a picture one of your albums!`, `<img src="${picture.imgUrl}" alt="a picture" class="w-100">`)
  }
}

export const picturesHandler = new PicturesHandler()
