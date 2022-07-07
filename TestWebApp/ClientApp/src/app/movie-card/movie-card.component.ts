import { Component, Input } from '@angular/core';
import { Movie } from "../../models/movie";
import { MatDialog } from "@angular/material/dialog";
import { MovieInfoModalComponent } from "../movie-info-modal/movie-info-modal.component";
import { Utils } from "../utils/utils";

@Component({
  selector: 'movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent {
  @Input() public movie: Movie | undefined;
  constructor(public dialog: MatDialog, public utils: Utils) {}

  openModal(): void {
    this.dialog.open(MovieInfoModalComponent, { data: this.movie });
  }
}
