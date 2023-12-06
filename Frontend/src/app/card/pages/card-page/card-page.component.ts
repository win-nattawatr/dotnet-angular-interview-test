import { Component } from '@angular/core';
import { CardComponent } from '../../components/card/card.component';
import { CardService } from '../../services/card.service';

@Component({
  selector: 'app-card-page',
  standalone: true,
  imports: [CardComponent],
  providers: [CardService],
  templateUrl: './card-page.component.html',
  styleUrl: './card-page.component.css',
})
export class CardPageComponent {
  constructor(private readonly _cardService: CardService) {}
}
