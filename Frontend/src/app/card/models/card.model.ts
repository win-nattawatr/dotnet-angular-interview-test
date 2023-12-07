export class Card {
  id?: number;
  name: string;
  base64ImageContent: string;

  constructor(data: Card) {
    this.id = data.id;
    this.name = data.name;
    this.base64ImageContent = data.base64ImageContent;
  }
}
