import { Routes } from '@angular/router';
import { CardPageComponent } from './card/pages/card-page/card-page.component';
import { AddCardPageComponent } from './card/pages/add-card-page/add-card-page.component';

export const routes: Routes = [
  {
    path: '',
    component: CardPageComponent,
  },
  {
    path: 'add-card',
    component: AddCardPageComponent,
  },
];
