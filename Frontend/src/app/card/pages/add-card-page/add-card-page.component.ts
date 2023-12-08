import { Component } from '@angular/core';
import { CardModule } from '../../card.module';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
  base64ImageContentFormControl: FormControl;
  isFileConverting: boolean;
  isPostingCard: boolean;

  constructor(
    private readonly _cardService: CardService,
    private router: Router
  ) {
    this.base64ImageContentFormControl = new FormControl(
      null,
      Validators.required
    );
    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      base64ImageContent: this.base64ImageContentFormControl,
    });

    this.isFileConverting = false;
    this.isPostingCard = false;
  }

  async onFileSelected(event: Event) {
    const inputFileElement = event.target as HTMLInputElement;
    if (inputFileElement.files && inputFileElement.files.length) {
      const file = inputFileElement.files.item(0);
      if (file) {
        await new Promise<void>((resolve, reject) => {
          this.isFileConverting = true;
          try {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => {
              this.base64ImageContentFormControl.setValue(reader.result);
              this.isFileConverting = false;
              resolve();
            };
          } catch (e) {
            this.isFileConverting = false;
            reject(e);
          }
        });
      }
    }
  }

  addCard() {
    if (this.form.valid && !this.isPostingCard) {
      const newCard = new Card(this.form.value);
      const subscription = this._cardService.addCard(newCard).subscribe({
        next: (res) => {
          if (res && res.id) {
            this.back();
          }
          subscription.unsubscribe();
        },
        error: () => {
          subscription.unsubscribe();
        },
      });
    }
  }

  back() {
    this.router.navigate(['']);
  }
}
