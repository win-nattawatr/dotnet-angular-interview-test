import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardService } from './services/card.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [],
  providers: [CardService],
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
  exports: [CommonModule, ReactiveFormsModule],
})
export class CardModule {}
