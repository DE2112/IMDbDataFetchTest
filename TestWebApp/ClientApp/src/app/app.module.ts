import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatCardModule } from "@angular/material/card";
import { MatPaginatorModule } from "@angular/material/paginator";

import { AppComponent } from './app.component';
import { IMDBDataComponent } from "./imdb-data/imdb-data.component";
import { MovieListComponent } from "./movie-list/movie-list.component";
import { MovieCardComponent } from "./movie-card/movie-card.component";
import { MovieInfoModalComponent } from "./movie-info-modal/movie-info-modal.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    IMDBDataComponent,
    MovieListComponent,
    MovieCardComponent,
    MovieInfoModalComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    MatProgressBarModule,
    MatGridListModule,
    MatCardModule,
    MatPaginatorModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent, pathMatch: 'full' },
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
