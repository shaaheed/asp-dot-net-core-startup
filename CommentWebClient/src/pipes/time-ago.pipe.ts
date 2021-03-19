import { Pipe, PipeTransform, NgZone, ChangeDetectorRef, OnDestroy, NgModule } from "@angular/core";
import { TranslateModule, TranslateService } from "@ngx-translate/core";
import { NumberService } from "src/services/number.service";
@Pipe({
	name: 'timeAgo',
	pure: false
})
export class TimeAgoPipe implements PipeTransform, OnDestroy {
	private timer: number;
	constructor(
		private changeDetectorRef: ChangeDetectorRef,
		private ngZone: NgZone,
		private translate: TranslateService,
		private numberService: NumberService
	) { }

	transform(value: string) {
		this.removeTimer();
		if (!value)
			return '—';
		let d = new Date(value);
		let now = new Date();
		let seconds = Math.round(Math.abs((now.getTime() - d.getTime()) / 1000));
		let timeToUpdate = (Number.isNaN(seconds)) ? 1000 : this.getSecondsUntilUpdate(seconds) * 1000;
		this.timer = this.ngZone.runOutsideAngular(() => {
			if (typeof window !== 'undefined') {
				return window.setTimeout(() => {
					this.ngZone.run(() => this.changeDetectorRef.markForCheck());
				}, timeToUpdate);
			}
			return null;
		});
		let minutes = Math.round(Math.abs(seconds / 60));
		let hours = Math.round(Math.abs(minutes / 60));
		let days = Math.round(Math.abs(hours / 24));
		let months = Math.round(Math.abs(days / 30.416));
		let years = Math.round(Math.abs(days / 365));
		if (Number.isNaN(seconds)) {
			return '';
		} else if (seconds <= 45) {
			return this.translate.instant('a.few.seconds.ago');
		} else if (seconds <= 90) {
			return this.translate.instant('a.minute.ago');
		} else if (minutes <= 45) {
			const minutesStr = this.numberService.convert(minutes.toString());
			return this.translate.instant('x0.minutes.ago', {x0: minutesStr});
		} else if (minutes <= 90) {
			return this.translate.instant('an.hour.ago');;
		} else if (hours <= 22) {
			const hoursStr = this.numberService.convert(hours.toString());
			return this.translate.instant('x0.hours.ago', {x0: hoursStr});
		} else if (hours <= 36) {
			return this.translate.instant('a.day.ago');
		} else if (days <= 6) {
			const daysStr = this.numberService.convert(days.toString());
			return this.translate.instant('x0.days.ago', {x0: daysStr});
		} else if (days <= 12) {
			return this.translate.instant('a.week.ago');
		} else if (days <= 27) {
			const weeks = Math.floor(25/7);
			const weeksStr = this.numberService.convert(weeks.toString());
			return this.translate.instant('x0.week.ago', {x0: weeksStr});
		} else if (days <= 45) {
			return this.translate.instant('a.month.ago');
		} else if (days <= 345) {
			const monthsStr = this.numberService.convert(months.toString());
			return this.translate.instant('x0.months.ago', {x0: monthsStr});
		} else if (days <= 545) {
			return this.translate.instant('a.year.ago');
		} else { // (days > 545)
			const yearsStr = this.numberService.convert(years.toString());
			return this.translate.instant('x0.years.ago', {x0: yearsStr});
		}
	}

	ngOnDestroy(): void {
		this.removeTimer();
	}

	private removeTimer() {
		if (this.timer) {
			window.clearTimeout(this.timer);
			this.timer = null;
		}
	}

	private getSecondsUntilUpdate(seconds: number) {
		let min = 60;
		let hr = min * 60;
		let day = hr * 24;
		if (seconds < min) { // less than 1 min, update every 2 secs
			return 2;
		} else if (seconds < hr) { // less than an hour, update every 30 secs
			return 30;
		} else if (seconds < day) { // less then a day, update every 5 mins
			return 300;
		} else { // update every hour
			return 3600;
		}
	}
}

@NgModule({
	declarations: [TimeAgoPipe],
	imports: [TranslateModule],
	exports: [TimeAgoPipe],
	providers: [TimeAgoPipe]
})
export class TimeAgoPipeModule { }