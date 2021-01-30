import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import FavoriteMusic from "app/model/favorite-music.model";
import User from "app/model/user.model";
import { PersistenceService } from "app/services/persistence.service";
import { UserService } from "app/services/user.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-favorite",
    templateUrl: "./favorite.component.html",
    styleUrls: ["./favorite.component.scss"],
})
export class FavoriteComponent implements OnInit {
    displayedColumns: string[] = [
        "position",
        "name",
        "duration",
        "action",
    ];
    dataSource: FavoriteMusic[];
    user: User;

    constructor(
        private userService: UserService,
        private persistence: PersistenceService,
        private router: Router
    ) {}

    ngOnInit() {
        this.user = this.persistence.get("authenticate_user");
        this.dataSource = this.user.favoriteMusics;
    }

    getMusicDuration(value: number) {
        const minutes: number = Math.floor(value / 60);
        return `${minutes.toString().padStart(2, "0")}:${(value - minutes * 60)
            .toString()
            .padStart(2, "0")}`;
    }

    removeFromFavorite(musicId) {
        this.userService.removeMusicFromFavorite(this.user.id, musicId)
            .subscribe(data => {
                this.persistence.set("authenticate_user", data);
                this.user = data;
                this.dataSource = this.user.favoriteMusics;
                Swal.fire(
                    "Sucesso!",
                    "Musica removida dos favoritos",
                    "success"
                );
            });
    }
}
