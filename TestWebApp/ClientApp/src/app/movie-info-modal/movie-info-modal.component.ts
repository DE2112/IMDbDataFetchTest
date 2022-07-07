import {Component, Inject} from '@angular/core';
import {Movie} from "../../models/movie";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
  selector: 'movie-info-modal',
  templateUrl: './movie-info-modal.component.html',
  styleUrls: ['./movie-info-modal.component.css']
})
export class MovieInfoModalComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: Movie) {}
}
