import { Component, OnDestroy, OnInit } from '@angular/core';
import { CardComponent } from '../../components/card/card.component';
import { CardService } from '../../services/card.service';
import { CardModule } from '../../card.module';
import { Card } from '../../models/card.model';
import { FormControl } from '@angular/forms';
import {
  Subscription,
  catchError,
  debounceTime,
  defer,
  of,
  switchMap,
  tap,
} from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card-page',
  standalone: true,
  imports: [CardModule, CardComponent],
  templateUrl: './card-page.component.html',
  styleUrl: './card-page.component.css',
})
export class CardPageComponent implements OnInit, OnDestroy {
  cards: Card[];
  searchTerm: FormControl;

  private searchTermSubscription?: Subscription;

  constructor(
    private readonly _cardService: CardService,
    private router: Router
  ) {
    this.cards = [];
    this.searchTerm = new FormControl(null);
  }

  ngOnInit(): void {
    this.initialSearch();
  }

  ngOnDestroy(): void {
    this.destroySearch();
  }

  private initialSearch() {
    this.searchTermSubscription = this.searchTerm.valueChanges
      .pipe(
        debounceTime(1000),
        switchMap((value) =>
          defer(() => this._cardService.getCards(value)).pipe(
            catchError(() => of<Card[]>([]))
          )
        )
      )
      .subscribe({
        next: (res) => {
          this.cards = res;
        },
      });

    this.searchTerm.patchValue(null);
  }

  private destroySearch() {
    this.searchTermSubscription?.unsubscribe();
  }

  addCard() {
    this.router.navigate(['add-card']);
  }
}
