import {Injectable} from "@angular/core";

@Injectable({ providedIn: "root" })
export class Utils{
  public isFieldEmpty(field: string): boolean {
    return field == "N/A";
  }
}
