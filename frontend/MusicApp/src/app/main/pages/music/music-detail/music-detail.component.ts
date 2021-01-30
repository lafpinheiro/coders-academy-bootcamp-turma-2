import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import Album from "app/model/album.model";
import Music from "app/model/music.model";
import User from "app/model/user.model";
import { MusicService } from "app/services/music.service";
import { PersistenceService } from "app/services/persistence.service";
import { UserService } from "app/services/user.service";
import { forkJoin } from "rxjs";
import Swal from "sweetalert2";

@Component({
    selector: "app-music-detail",
    templateUrl: "./music-detail.component.html",
    styleUrls: ["./music-detail.component.scss"],
})
export class MusicDetailComponent implements OnInit {
    private albumId: string;
    album: Album;
    user: User;

    constructor(
        private service: MusicService,
        private router: Router,
        private route: ActivatedRoute,
        private persistence: PersistenceService,
        private userService: UserService
    ) {}

    ngOnInit() {
        this.albumId = this.route.snapshot.paramMap.get("id");
        this.user = this.persistence.get("authenticate_user");

        this.service.getAlbumsDetail(this.albumId).subscribe((data) => {
            this.album = data;
        });
    }

    getMusicDuration(value: number) {
        const minutes: number = Math.floor(value / 60);
        return `${minutes.toString().padStart(2, "0")}:${(value - minutes * 60)
            .toString()
            .padStart(2, "0")}`;
    }

    back() {
        this.router.navigate(["page", "music"]);
    }

    isFavoriteMusic(musicId) {
        return (
            this.user.favoriteMusics.findIndex((x) => x.musicId == musicId) !=
            -1
        );
    }

    toogleMusicFavorite(musicId) {
        if (this.isFavoriteMusic(musicId) == false) {
            this.userService.addMusicToFavorite(this.user.id, musicId)
                .subscribe(data => {
                    this.persistence.set("authenticate_user", data);
                    this.user = data;
                     Swal.fire(
                         "Sucesso!",
                         "Musica adicionada ao favoritos",
                         "success"
                     );
                });
        } else {
            this.userService
                .removeMusicFromFavorite(this.user.id, musicId)
                .subscribe((data) => {
                    this.persistence.set("authenticate_user", data);
                    this.user = data;
                    Swal.fire(
                        "Sucesso!",
                        "Musica removida dos favoritos",
                        "success"
                    );
                });
        }
    }
}
