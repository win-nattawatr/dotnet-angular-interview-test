import { Component, OnDestroy, OnInit } from '@angular/core';
import { CardModule } from '../../card.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import {
  Subscription,
  debounceTime,
  switchMap,
  defer,
  catchError,
  of,
} from 'rxjs';
import { Card } from '../../models/card.model';
import { CardService } from '../../services/card.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-card-page',
  standalone: true,
  imports: [CardModule],
  templateUrl: './add-card-page.component.html',
  styleUrl: './add-card-page.component.css',
})
export class AddCardPageComponent {
  form: FormGroup;

  constructor(
    private readonly _cardService: CardService,
    private router: Router
  ) {
    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      image: new FormControl(null, Validators.required),
    });
  }

  addCard() {
    console.log(this.form.valid);
    if (this.form.valid) {
      console.log(this.form.get('image')?.value);
    }
  }

  back() {
    this.router.navigate(['']);
  }
}
