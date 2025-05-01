import { Profile } from "./Account.js"
import { Album } from "./Album.js"

// NOTE will probably never create a "Watcher", so we don't need to export this class
class Watcher {
  constructor(data) {
    this.id = data.id
    this.accountId = data.accountId
    this.albumId = data.albumId
  }
}

// NOTE sometimes the watcher has a profile
export class WatcherProfile extends Watcher {
  constructor(data) {
    super(data)
    this.profile = new Profile(data.profile)
  }
}

// NOTE sometimes the watcher has an album
export class WatcherAlbum extends Watcher {
  constructor(data) {
    super(data)
    this.album = new Album(data.album)
  }
}
