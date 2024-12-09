import { Component, ElementRef, AfterViewInit, PLATFORM_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { RouterLink } from '@angular/router';
import Lottie from 'lottie-web';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements AfterViewInit {

  private isBrowser: boolean;

  constructor(
    private elementRef: ElementRef,
    @Inject(PLATFORM_ID) platformId: object // Inject platform information
  ) {
    this.isBrowser = isPlatformBrowser(platformId); // Check if running in the browser
  }

  async ngAfterViewInit(): Promise<void> {
    if (this.isBrowser) {
      // Import lottie-web dynamically for browser execution
      const lottie = await import('lottie-web');

      lottie.default.loadAnimation({
        container: this.elementRef.nativeElement.querySelector('#lottie-container'), // Animation container
        renderer: 'svg',
        loop: true,
        autoplay: true,
        path: './VdwV8ORk9m.json', // Path to Lottie JSON file
      });
    }
  }

}
