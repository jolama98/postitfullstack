import { Profile } from "./Account.js"

export class Picture {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.albumId = data.albumId
    this.imgUrl = data.imgUrl
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.creator = new Profile(data.creator)
  }
}
