export class Profile {
  constructor(data) {
    this.id = data.id
    this.name = data.id
    this.picture = data.picture
  }
}

export class Account extends Profile {
  /**
   * @typedef AccountData
   * @property {string} id
   * @property {string} email
   * @property {string} name
   * @property {string} picture
   *
   * @param {AccountData} data
   */
  constructor(data) {
    super(data)
    this.email = data.email


  }
}
