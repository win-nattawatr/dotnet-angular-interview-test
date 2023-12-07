import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Card } from '../models/card.model';
import { map } from 'rxjs';

@Injectable()
export class CardService {
  private readonly _baseApiUrl: string;

  constructor(private readonly _httpClient: HttpClient) {
    this._baseApiUrl = environment.apiBaseUrl;
  }

  getCards(searchTerm?: string) {
    return this._httpClient
      .get<Card[]>(
        `${this._baseApiUrl}/api/Card/GetCards${
          searchTerm ? `?searchTerm=${searchTerm}` : ''
        }`
      )
      .pipe(map((cards) => cards.map((card) => new Card(card))));
  }

  addCard(newcard: Card) {
    return this._httpClient
      .post<Card>(`${this._baseApiUrl}/api/Card/AddCard`, newcard)
      .pipe(map((card) => new Card(card)));
  }
}
